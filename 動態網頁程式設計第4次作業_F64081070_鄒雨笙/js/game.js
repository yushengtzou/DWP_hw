/*
F64081070 鄒雨笙 第4次作業 5/17
F64081070 Yu Sheng Tzou The Forth Homework 5/17
*/

let usedCards = [];

function displayBank() {
    var bank = localStorage.getItem("bank");
    $("#money").html("$" + bank);
}

function getRandomSuit() {
    var suits = ['diamonds', 'hearts', 'clubs', 'spades'];
    var randomIndex = Math.floor(Math.random() * suits.length);
    return suits[randomIndex];
}

function getRandomCardValue() {
    let value = Math.floor(1 + Math.random() * 13);
    return value > 10 ? 10 : value;
}

function getCardImagePath(suit, value) {
    return '../image/poker/' + suit + '/' + value + '.png';
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
    var cardsContainer = $("#" + cardsContainerId);
    var totalValue = parseInt($("#" + totalValueId).text(), 10);

    var card = generateUniqueCard(usedCards);
    usedCards.push(card);

    var suit = card.suit;
    var value = card.value;
    totalValue += value;
    var cardImgSrc = getCardImagePath(suit, value);

    var cardImgElement = $("<img>", {
        src: cardImgSrc,
        class: 'card'
    });
    cardsContainer.append(cardImgElement);

    $("#" + totalValueId).text(totalValue);
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
        bank -= betAmount;
    }
    updateBank(bank);
}

function hit() {
    dealCardToPlayer();

    var playerTotalValue = parseInt($("#playerTotalValue").text(), 10);
    var dealerTotalValue = parseInt($("#dealerTotalValue").text(), 10);
    var betAmount = 100;
    
    if (playerTotalValue > 21) {
        $("#playerBust").show();
        $("#dealerWin").show();
        gameResult(false, betAmount);
    } else if (dealerTotalValue > 21) {
        $("#dealerBust").show();
        $("#playerWin").show();
        gameResult(true, betAmount);
    } else if (playerTotalValue > 21 && dealerTotalValue > 21) {
        $("#push").show();
    }
}

function stand() {
    var dealerTotalValue = parseInt($("#dealerTotalValue").text(), 10);
    var playerTotalValue = parseInt($("#playerTotalValue").text(), 10);
    var betAmount = 100;

    dealCardToDealer();
    dealerTotalValue = parseInt($("#dealerTotalValue").text(), 10);


    if (dealerTotalValue > 21) {
        $("#dealerBust").show();
        $("#playerWin").show();
        gameResult(true, betAmount);
        setTimeout(() => {
            window.history.back();
        }, 2700);
    } else if (dealerTotalValue >= playerTotalValue) {
        $("#dealerWin").show();
        gameResult(false, betAmount);
        setTimeout(() => {
            window.history.back();
        }, 2700);
    }
}

$(document).ready(function() {
    displayDealerAndPlayerCards();
    displayBank();

    $("#hit").click(function() {
        hit();
    });

    $("#stand").click(function() {
        stand();
    });
});

