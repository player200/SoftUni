function isSymmetric(arr) {
    if (!Array.isArray(arr))
    {
        return false
    }

    let reversed = arr.slice(0).reverse()
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed))

    return equal
}

module.exports = {isSymmetric}