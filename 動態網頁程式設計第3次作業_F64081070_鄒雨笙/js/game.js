function displayBank() {
    var bank = localStorage.getItem("bank");
    document.getElementById("money").innerHTML = "$" + bank;
}

window.addEventListener("load", displayBank, false);

