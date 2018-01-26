function rounding(params) {
    console.log(Math.round(params[0]* Math.pow(10,params[1]))/Math.pow(10,params[1]))
}

rounding([3.1415926535897932384626433832795, 2])