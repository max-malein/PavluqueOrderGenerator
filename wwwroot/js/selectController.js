console.log("loaded!")
var productsPromise = fetch('/Index?handler=sizes')
    .then(response => response.json())

// добавить события для первого ряда
addInputChangeListeners(document.querySelector('#inputRows > div'))

function createRow(button) {
    let row = button.parentNode.parentNode
    let rIndex = parseInt(row.dataset.rowindex)

    if (button.innerHTML == "+") {        
        let newRow = row.cloneNode(true)        
        console.log("row index ", rIndex)
        newRow.dataset.rowindex = 1 + rIndex

        setRowIndex(newRow, 1 + rIndex)
        button.innerHTML = "-"

        addInputChangeListeners(newRow)

        row.parentNode.append(newRow)
    }
    else {
        row.remove()

        // renumber rows
        let rows = document.querySelectorAll("#inputRows > div")
        for (var i = 0; i < rows.length; i++) {
            setRowIndex( rows[i], i)            
        }
    }
}

function setRowIndex(row, index) {

    row.dataset.rowindex = index;
    [...row.querySelectorAll('div > * [name^=Orders]')].map(input => {
        input.name = input.name.replace(/(?<=Orders\[)[\dNan)]+/gm, index)
    })
}

function selectProductName(select) {
    let selection = select.options[select.selectedIndex].text
    let sizeElement = select.parentNode.nextElementSibling.getElementsByTagName('select')[0]

    let size = productsPromise.then(sz => {
        sizeArr = sz.filter(o => o.name == selection)[0].sizes
        setSizes(sizeElement, sizeArr)
    })
}

function setSizes(element, selectOptions) {
    console.dir(element)
    console.dir(selectOptions)
    let currentSize = element.options[element.selectedIndex].text

    // удалить текущие опции
    if (element.options.length > 1) {
        for (let i = element.options.length - 1; i > 0; --i) {
            element.options[i].remove()
        }
    }

    // установить новые опции
    for (let op of selectOptions) {
        let option = new Option(op)
        element.options.add(option)

        // сохранить установленный размер по возможности
        if (currentSize == op) {
            element.selectedIndex = option.index
        }
    }
}

function increaseNameIndexes(row) {
    let html = row.innerHTML
    const replacePattern = /(?<=name="Orders\[)\d+/gm
    row.innerHTML = html.replace(replacePattern, row.dataset.rowindex)
}



function updateSku(event) {
    console.log('inside updateSku event')
    let row = event.currentTarget.closest('.input-row')
    let productName = row.querySelector('.product-name').value
    let qty = row.querySelector('.product-quantity').value
    let size = row.querySelector('.product-size').value

    let priceInput = row.querySelector('.product-price')
    let skuInput = row.querySelector('.product-sku')

    productsPromise.then(prods => {
        let product = prods.filter(p => p.name == productName)[0]

        if (size == "Размер") {
            size = ""
        }

        let sku = ""
        let price = ""
        if (product != null) {
            sku = product.sku + '-' + size
            price = product.price
        }
        
        skuInput.value = sku
        priceInput.value = price
    })
}

function onSkuUpdate(event) {
    let input = event.currentTarget
    // тип изделия
    const pattern = /(^\d{5})(-(\w*)$)?/m;
    let match = input.value.match(pattern)
    if (match != null && match[1]) {
        console.log(match[1])
        productsPromise.then(prods => {
            let product = prods.filter(p => p.sku == match[1])[0]
            if (product) {
                let prodInput = input.closest('.input-row').querySelector('.product-name');
                for (let i = 0; i < prodInput.options.length; i++) {
                    if (prodInput.options[i].text == product.name) {
                        prodInput.selectedIndex = i
                        break
                    }
                }
            }
        })
    }
}


function addInputChangeListeners(row) {
    row.querySelector('.product-sku').addEventListener('input', onSkuUpdate)
    let elements = row.getElementsByClassName('product-input')
    for (var i = 0; i < elements.length; i++) {
        elements[i].addEventListener('change', updateSku)
    }
}