function listProcessor(commands) {
    let commandProcessor = (function(){
        let collector=[]
        return{
            add:(itemToAdd)=>{
                collector.push(itemToAdd)
            },
            remove:(itemToRemove)=>{
                collector = collector
                    .filter(x => x != itemToRemove)
            },
            print:() => {
                console.log(collector.join(','))
            }
        }
    })()
    for (let comand of commands) {
        let [comandName, arg] = comand.split(' ')
        commandProcessor[comandName](arg)
    }
}

listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print'])