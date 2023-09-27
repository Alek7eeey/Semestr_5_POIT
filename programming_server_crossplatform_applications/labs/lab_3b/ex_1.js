const firstJob = async () => {
   return new Promise((resolve, reject) => {
        setTimeout(() => {
            try {
                resolve("Hello world");
            } catch (e) {
                reject(e);
            }
        }, 2000)
   });
}

//     try {
//     const result = await firstJob();
//     console.log(result);
// } catch (e) {
//     console.warn(e)
// }

firstJob()
    .then((result)=>{
        console.log(`Promise finish work success: `, result)
    })
    .catch((err)=>{
        console.log(`Promise finish work error: `, err)
    });