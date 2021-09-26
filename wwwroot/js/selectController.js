console.log("loaded!")
//var sizes = async () => {
//    let response = await fetch("/Index?handler=sizes")
//    if (!response.ok) {
//        console.error("не удалось прочитать список размеров")
//        return null
//    }

//    let result = await response.json()
//    return result
//}
var sizesPromise = fetch('/Index?handler=sizes')
    .then(response => response.json())

function createRow(button) {
    let row = button.parentNode.parentNode
    let rIndex = row.name

    if (button.innerHTML == "+") {        
        let newRow = row.cloneNode(true)        
        console.log("row index ", rIndex)
        newRow.name = ++row.name

        testfunc()
        increaseNameIndexes(newRow)
        button.innerHTML = "-"

        row.parentNode.append(newRow)

        console.debug('test')
    }
    else {
        row.remove()
        let rows = document.querySelectorAll("#inputRows > div > div> *[name^='Orders']")
        console.debug(rows.lenth)
    
    }
}

function selectProductName(select) {
    let selection = select.options[select.selectedIndex].text
    let sizeElement = select.parentNode.nextElementSibling.getElementsByTagName('select')[0]
    let size = sizesPromise.then(sz => {
        sizeArr = sz[selection]
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
    row.innerHTML = html.replace(replacePattern, row.name)
}

function testfunc() {
    console.log('shit')
}