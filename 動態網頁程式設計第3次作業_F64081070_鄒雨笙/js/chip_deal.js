/*
F64081070 鄒雨笙 第3次作業 5/2
F64081070 Yu Sheng Tzou The Third Homework 5/2
*/

var bank = 1000;
var chip = 0;
var all_in;

document.writeln("<div id='money'>");
document.writeln( "$" + bank + "</h1>" );
document.writeln("</div>");

document.writeln("<div id='chipToDeal' style='display: none;'>");
document.writeln( "$" + chip );
document.writeln("</div>");

function start() {
    all_in = document.getElementById("all_in");
    all_in.addEventListener("click", allIn, false);

    var chips = document.getElementsByClassName("chip");
    for (var i = 0; i < chips.length; i++) {
        chips[i].addEventListener("click", chipDeal, false);
    }
}

function allIn() {
    bank = 0;
    document.getElementById("money").innerHTML = "$" + bank;
    chip = 1000 - bank;
    chipToDeal(chip);
    deal();
    localStorage.setItem("bank", bank);
}

function chipDeal(event) {
    var chipId = event.target.id;
    var newBankValue;

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
    document.getElementById("money").innerHTML = "$" + bank;
    localStorage.setItem("bank", bank);
}

function chipToDeal(chip) {
    var chipToDealDiv = document.getElementById("chipToDeal");
    chipToDealDiv.innerHTML = "$" + chip;
    chipToDealDiv.style.display = "block";
}

function deal() {
    var deal = document.getElementById("deal");
    deal.style.display = "block";
}

window.addEventListener( "load", start, false );
