
const sqrt = async (num) =>{
    return new Promise((resolve, reject)=>{
        setTimeout(()=>{
            if(Number.isFinite(num)){
                resolve(Math.sqrt(num));
            }
            else {
                reject("Not correct input!");
            }
        }, 1500)
    })
};

const cubeNum = async (num) =>{
    return new Promise((resolve, reject)=>{
        setTimeout(()=>{
            if(Number.isFinite(num)){
                resolve(Math.pow(num, 3));
            }
            else {
                reject("Not correct input!");
            }
        }, 500)
    })
}

const fourthPowNum = async (num) =>{
    setTimeout(()=>{
        return new Promise((resolve, reject)=>{
            if(Number.isFinite(num)){
                resolve(Math.pow(num, 4));
            }
            else {
                reject("Not correct input!");
            }
        })
    }, 2000)
}

Promise.race([await cubeNum(10),await fourthPowNum(15), await sqrt(9)])
    .then((data)=>{
        console.log("success: ", data);
    })
    .catch((err)=>{
        console.log(err);
    })

// Promise.any([await cubeNum(10),await fourthPowNum(15), await sqrt(9)])
//     .then((data)=>{
//         console.log("success: ", data);
//     })
//     .catch((err)=>{
//         console.log(err);
//     })