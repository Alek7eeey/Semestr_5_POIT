

const secondJob = async () => {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            reject("Fatal error((");
        }, 3000);
    });
};

// secondJob.then((resolve)=>{
//     console.log("All success: " + resolve);
// })
//     .catch((err)=>{
//         console.log("Error: " + err);
//     })


    try {
        const result = await secondJob();
        console.log(result);
    } catch (e) {
        console.warn(e);
    }
