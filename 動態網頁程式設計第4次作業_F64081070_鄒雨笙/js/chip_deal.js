/*
F64081070 鄒雨笙 第4次作業 5/17
F64081070 Yu Sheng Tzou The Forth Homework 5/17
*/

let bank = 1000;
let chip = 0;
let all_in;

$('body').append("<div id='money'>");
$('body').append( "$" + bank + "</h1>" );
$('body').append("</div>");

$('body').append("<div id='chipToDeal' style='display: none;'>");
$('body').append( "$" + chip );
$('body').append("</div>");

function start() {
    $('#all_in').on('click', allIn);

    $('.chip').each(function() {
        $(this).on('click', chipDeal);
    });
}

function allIn() {
    bank = 0;
    $('#money').html("$" + bank);
    chip = 1000 - bank;
    chipToDeal(chip);
    deal();
    localStorage.setItem("bank", bank);
}

function chipDeal(event) {
    let chipId = event.target.id;
    let newBankValue;

    switch (chipId) {
        case "chip1":
            newBankValue = bank - 1;
            break;
        case "chip5":
            newBankValue = bank - 5;
            break;
        case "chip25":
            newBankValue = bank - 25;
            break;
        case "chip50":
            newBankValue = bank - 50;
            break;
        case "chip100":
            newBankValue = bank - 100;
            break;
        case "chip500":
            newBankValue = bank - 500;
            break;
        case "chip1000":
            newBankValue = 0;
            break;
        default:
            return;
    }

    bank = newBankValue >= 0 ? newBankValue : 0;
    chip = 1000 - bank;
    chipToDeal(chip);
    deal();
    $("#bankValue").html(bank);
    localStorage.setItem("bank", bank);
}

function chipToDeal(chip) {
    $('#chipToDeal').html("$" + chip);
    $('#chipToDeal').show();
}

function deal() {
    $('#deal').show();
}

let ads = [
    '../image/ad1.png',
    '../image/ad2.jpeg',
    '../image/ad3.jpeg'
    // add more ad image paths here...
];

function displayRandomAd() {
    let adIndex = Math.floor(Math.random() * ads.length);
    let adImgSrc = ads[adIndex];

    let adImgElement = $('<img>');
    adImgElement.attr({
        src: adImgSrc,
        alt: 'Advertisement',
        class: 'ad'
    });

    $('#adContainer').html(''); 
    $('#adContainer').append(adImgElement);
}

displayRandomAd();
setInterval(displayRandomAd, 3000);

setInterval(function(){
    alert("Don't forget to place your bet!");
}, 10000);

$(document).ready(function() {
    start();
});

