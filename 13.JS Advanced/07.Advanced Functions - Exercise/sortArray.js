function sortArray(arr,sorter) {
    if(sorter==='asc'){
        arr.sort(function(a, b) {
            return a - b
        });
    }
    else if(sorter==='desc'){
        arr.sort(function(a, b) {
            return b - a
        });
    }
    return arr
}

console.log(sortArray([3, 1, 2, 10, 4, 8, 5, 7, 9, 20, 6], 'desc'));