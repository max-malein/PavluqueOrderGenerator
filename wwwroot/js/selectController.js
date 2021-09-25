console.log("loaded!")

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
    var selection = select.options[select.selectedIndex].text
    console.debug(selection)

}

function increaseNameIndexes(row) {
    let html = row.innerHTML
    const replacePattern = /(?<=name="Orders\[)\d+/gm
    row.innerHTML = html.replace(replacePattern, row.name)
}

function testfunc() {
    console.log('shit')
}