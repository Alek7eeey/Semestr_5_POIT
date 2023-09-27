
const sqrt = async (num) =>{
      return new Promise((resolve, reject)=>{
          if(Number.isFinite(num)){
              resolve(Math.sqrt(num));
          }
          else {
              reject("Not correct input!");
          }
      })
};

const cubeNum = async (num) =>{
    return new Promise((resolve, reject)=>{
        if(Number.isFinite(num)){
            resolve(Math.pow(num, 3));
        }
        else {
            reject("Not correct input!");
        }
    })
}

const fourthPowNum = async (num) =>{
    return new Promise((resolve, reject)=>{
        if(Number.isFinite(num)){
            resolve(Math.pow(num, 4));
        }
        else {
            reject("Not correct input!");
        }
    })
}

Promise.all([cubeNum(10), fourthPowNum(15), sqrt(9), { key: 'I am a data!'}])
    .then((data)=>{
        console.log("success: ", data);
    })
    .catch((err)=>{
        console.log(err);
    })