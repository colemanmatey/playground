// Create a cart
let cart = [];

function addProductToCart(item) {
    let product = document.getElementById(item);
    let productName = product.getElementsByTagName("h2")[0].innerText;
    let unitPrice = parseFloat(
        product.getElementsByTagName("span")[0].innerText
    );

    // Validate quantity
    let quantity = 0;
    do {
        quantity = +prompt(`Enter quantity for ${productName}`);
        if (isNaN(quantity)) {
            alert("Quantity must be a number.");
        } else if (quantity < 1) {
            alert("Quantity cannot be zero. Enter a value more than zero");
        }
    } while (isNaN(quantity) || quantity < 1);

    // Create a paragraph element to hold quantity
    let p = document.createElement("p");
    p.style.color = "#577399";

    // Ensure that a quantity of 0 is not displayed when the user adds product to cart
    if (quantity > 0) {
        p.append(`Quantity: ${quantity}`);
    }

    // Append span to the product article
    product.insertAdjacentElement("beforeend", p);

    let tocart = {
        product: productName,
        unitPrice: unitPrice,
        quantity: quantity,
        amount: unitPrice * quantity,
    };

    // Ensure that cart does not have a product with zero quantity
    if (quantity > 0) {
        cart.push(tocart);
    }
}

function checkout() {
    if (cart.length == 0) {
        alert("You have to select some products in order to checkout");
    } else {
        processOrder();
    }
}

function processOrder() {
    // Display receipt section after checkout
    let receipt = document.getElementById("receipt");
    receipt.style.display = "block";

    // Write order detail on receipt

    let customerName;
    do {
        customerName = prompt("Enter your name to place your order:");
        if (customerName.trim() === "" || customerName == null) {
            alert("Please enter a valid name");
        }
    } while (customerName.trim() === "" || customerName == null);

    let customer = document.getElementById("customer");
    let orderDate = document.getElementById("order-date");

    customer.innerText = customerName;
    orderDate.innerText = new Date(Date.now());

    // Add row to HTML Table
    let tbody = document.getElementById("data");
    let sn = 1;

    for (let i = 0; i < cart.length; i++) {
        let row = `<tr>
            <td>${sn}</td>
            <td>${cart[i].product}</td>
            <td>$${cart[i].unitPrice}</td>
            <td>${cart[i].quantity}</td>
            <td>$${cart[i].amount.toFixed(2)}</td>
        </tr>`;
        tbody.innerHTML += row;
        sn += 1;
    }

    // Calculate totals
    let subtotal = parseFloat(calculateSubTotal());
    let tax = calculateTax(subtotal);
    let total = calculateTotal(subtotal, tax);

    // Get HTML elements
    let sub = document.getElementById("subtotal");
    let gst = document.getElementById("tax");
    let grand = document.getElementById("total");

    // Assign totals to elements
    sub.innerText = subtotal.toFixed(2);
    gst.innerText = tax.toFixed(2);
    grand.innerText = total.toFixed(2);
}

function calculateSubTotal() {
    let subtotal = 0;
    for (let i = 0; i < cart.length; i++) {
        subtotal = subtotal + cart[i].amount;
    }
    return subtotal;
}

function calculateTax(subtotal) {
    const TAX_RATE = 0.13;
    return TAX_RATE * subtotal;
}

function calculateTotal(subtotal, tax) {
    return subtotal + tax;
}
