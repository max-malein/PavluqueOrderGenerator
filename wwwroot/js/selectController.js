console.log("loaded!")
var sizesPromise = fetch('/Index?handler=sizes')
    .then(response => response.json())

function createRow(button) {
    let row = button.parentNode.parentNode
    let rIndex = parseInt(row.dataset.rowindex)

    if (button.innerHTML == "+") {        
        let newRow = row.cloneNode(true)        
        console.log("row index ", rIndex)
        newRow.dataset.rowindex = 1 + rIndex

        setRowIndex(newRow, 1 + rIndex)
        button.innerHTML = "-"

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
    let size = sizesPromise.then(sz => {
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

function testfunc() {
    console.log('shit')
}