

const thirdJob = async (data) =>{
    return new Promise((resolve, reject)=>{
        if(!Number.isInteger(data)){
            reject("This is not a number!");
        }
        else if(data%2!==0){
            setTimeout(()=>{
                resolve("odd");
            }, 1000);
        }
        else {
            setTimeout(()=>{
                resolve("even");
            }, 2000);
        }
    })
};


thirdJob("sdds")
    .then((res)=>{
        console.log("Success: " + res);
    })
    .catch((err)=>{
        console.log("Err: " + err);
    })


// try{
//     const res = await thirdJob(13);
//     console.log("result: " + res);
// }
// catch (e)
// {
//     console.warn(e);
// }