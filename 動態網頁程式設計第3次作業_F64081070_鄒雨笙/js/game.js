let usedCards = [];

function displayBank() {
    var bank = localStorage.getItem("bank");
    document.getElementById("money").innerHTML = "$" + bank;
}

// 以下程式碼用以隨機發牌
function getRandomSuit() {
    var suits = ['diamonds', 'hearts', 'clubs', 'spades'];
    var randomIndex = Math.floor(Math.random() * suits.length);
    return suits[randomIndex];
}

function getRandomCardValue() {
    return Math.floor(1 + Math.random() * 13);
}

function getCardImagePath(suit, value) {
    return '../image/poker/' + suit + '/' + value + '.png'; // Replace 'path/to/cards/' with the actual path to your card images
}

function generateUniqueCard(usedCards) {
    let suit, value, card;
    do {
        suit = getRandomSuit();
        value = getRandomCardValue();
        card = { suit: suit, value: value };
    } while (usedCards.some(usedCard => usedCard.suit === card.suit && usedCard.value === card.value));
    return card;
}

function displayRandomCards(cardsContainerId, totalValueId, usedCards) {
    var cardsContainer = document.getElementById(cardsContainerId);
    var totalValue = parseInt(document.getElementById(totalValueId).innerText, 10);

    var card = generateUniqueCard(usedCards);
    usedCards.push(card);

    var suit = card.suit;
    var value = card.value;
    totalValue += value;
    var cardImgSrc = getCardImagePath(suit, value);

    var cardImgElement = document.createElement('img');
    cardImgElement.src = cardImgSrc;
    cardImgElement.className = 'card';
    cardsContainer.appendChild(cardImgElement);

    document.getElementById(totalValueId).innerText = totalValue;
}

function displayDealerAndPlayerCards() {
    displayRandomCards('dealerCards', 'dealerTotalValue', usedCards);
    displayRandomCards('playerCards', 'playerTotalValue', usedCards);
}
function dealCardToPlayer() {
    displayRandomCards('playerCards', 'playerTotalValue', usedCards);
}

function dealCardToDealer() {
    displayRandomCards('dealerCards', 'dealerTotalValue', usedCards);
}

function updateBank(newBankValue) {
    localStorage.setItem("bank", newBankValue);
    displayBank();
}

function gameResult(playerWin, betAmount) {
    var bank = parseInt(localStorage.getItem("bank"), 10);
    if (playerWin) {
        bank += betAmount * 2;
    } else {
        bank -= betAmount * 2;
    }
    updateBank(bank);
}

function hit() {
    dealCardToPlayer();
    dealCardToDealer();

    var playerTotalValue = parseInt(document.getElementById("playerTotalValue").innerText, 10);
    var dealerTotalValue = parseInt(document.getElementById("dealerTotalValue").innerText, 10);
    var betAmount = 100; // Change this value to the actual bet amount
    
    if (playerTotalValue > 21) {
        document.getElementById("playerBust").style.display = "block";
        document.getElementById("dealerWin").style.display = "block";
        gameResult(false, betAmount);
        setTimeout(() => {
            window.history.back();
        }, 2700); // Delay the navigation by 3 seconds (3000 milliseconds) to show the images before going back

    } else if (dealerTotalValue > 21) {
        document.getElementById("dealerBust").style.display = "block";
        document.getElementById("playerWin").style.display = "block";
        gameResult(true, betAmount);
        setTimeout(() => {
            window.history.back();
        }, 2700); // Delay the navigation by 3 seconds (3000 milliseconds) to show the images before going back

    } else if (playerTotalValue > 21 && dealerTotalValue > 21) {
        document.getElementById("push").style.display = "block";
        // No change in the bank value as it's a push
        setTimeout(() => {
            window.history.back();
        }, 2700); // Delay the navigation by 3 seconds (3000 milliseconds) to show the images before going back
    }

}


function stand() {
    // Add logic for the stand action here
}

function addListeners() {
    document.getElementById("hit").addEventListener("click", hit, false);
    document.getElementById("stand").addEventListener("click", stand, false);
}


window.addEventListener('load', displayDealerAndPlayerCards, false);
window.addEventListener("load", displayBank, false);
window.addEventListener("load", addListeners, false);



