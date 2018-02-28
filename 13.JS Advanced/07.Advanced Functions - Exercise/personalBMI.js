function personalBMI() {
    let collection={}
    let name = arguments[0]
    let age = arguments[1]
    let weight = arguments[2]
    let height = arguments[3]

    collection['name']=name
    collection['personalInfo']={}
    collection['personalInfo']['age']=age
    collection['personalInfo']['weight']=weight
    collection['personalInfo']['height']=height
    let bmi=weight/((height*height)/10000)
    collection['BMI']=Math.round(bmi)
    let status=getStatus(Math.round(bmi))
    collection['status']=status
    if(status==='obese'){
        collection['recommendation']='admission required'
    }

    function getStatus(bmi) {
        if(bmi<18.5){
            return 'underweight'
        }
        else if(bmi<25){
            return 'normal'
        }
        else if(bmi<30){
            return 'overweight'
        }
        else if(bmi>=30){
            return'obese'
        }
    }

    return collection
}

console.log(personalBMI("Honey Boo Boo", 9, 57, 137));