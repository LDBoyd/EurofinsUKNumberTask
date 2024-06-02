const uri = 'api/Numbers';
let numbers = [];

function displayItems(numbers) {

    var numbersDisplayDiv = document.getElementById('numberDisplay');
    numbersDisplayDiv.innerHTML = "";

    numbers.forEach(item => {
        var className;
        if (item == "Eurofins") {
            className = "number eurofins"
        } else if (item == "Five") {
            className = "number five"
        } else if (item == "Three") {
            className = "number three"
        } else {
            className = "number"
        }
        numbersDisplayDiv.innerHTML += `<p class="${className}">${item}</p>`;
    })  


}

function addItem() {

    var minValueInput = document.getElementById('minValue');
    var maxValueInput = document.getElementById('maxValue');

    var minValueInputVal;
    var maxValueInputVal;

    if (minValueInput.value.trim() == "") {
        minValueInputVal = 1
    } else {
        minValueInputVal = parseInt(minValueInput.value.trim())
    }
    
    if (maxValueInput.value.trim() == "") {
        maxValueInputVal = 100
    } else {
        maxValueInputVal = parseInt(maxValueInput.value.trim())
    }

    const item = {
        minValue: minValueInputVal,
        maxValue: maxValueInputVal
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok')
            }
            return response.json();
        })
        .then(data => {
            numbers = [data];
            displayItems(numbers[0])
        })
        .catch(error => console.error('Unable to add item.' + error));
}

