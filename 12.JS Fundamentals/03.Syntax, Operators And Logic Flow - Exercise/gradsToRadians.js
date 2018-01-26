function gradsToRadians(grad) {
    let degrees = grad * 0.9;

    degrees = degrees % 360;
    degrees = degrees < 0 ? (360 + degrees) : degrees;
    console.log(degrees);
}

gradsToRadians(-50)