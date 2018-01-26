function cone(radius,height) {
    console.log((Math.PI * radius * radius * height) / 3)
    console.log(Math.PI * radius*(radius + Math.sqrt(radius*radius + height*height)))
}

cone(3, 5)