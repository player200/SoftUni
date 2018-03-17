class MailBox {
    constructor() {
        this.mailbox = []
    }

    get messageCount() {
        return this.mailbox.length
    }

    addMessage(subject, text) {
        let objToAdd = {
            'subject': subject,
            'text': text
        }
        this.mailbox.push(objToAdd)

        return this
    }

    deleteAllMessages() {
        this.mailbox = []
    }

    findBySubject(substr) {
        let coll = []
        for (let i = 0; i < this.messageCount; i++) {
            coll.push(this.mailbox[i].subject)
        }
        let resultToPrint = []
        for (let i = 0; i < coll.length; i++) {
            if (coll[i].includes(substr)) {
                resultToPrint.push(this.mailbox[i])
            }
        }
        if (this.messageCount === 0
            || resultToPrint.length === 0) {
            return []
        }
        else {
            return resultToPrint
        }
    }

    toString() {
        if (this.messageCount === 0) {
            return ' * (empty mailbox)'
        }
        let outPut = ''
        for (let i = 0; i < this.messageCount; i++) {
            let currentSubject = this.mailbox[i].subject
            let currentText = this.mailbox[i].text
            if (i === this.messageCount - 1) {
                outPut += ` * [${currentSubject}] ${currentText}`
            }
            else {
                outPut += ` * [${currentSubject}] ${currentText}\n`
            }
        }

        return outPut
    }
}

let mb = new MailBox();
console.log("Msg count: " + mb.messageCount);
//Msg count: 0
console.log('Messages:\n' + mb);
//Messages:
//* (empty mailbox)
mb.addMessage("meeting", "Let's meet at 17/11");
mb.addMessage("beer", "Wanna drink beer tomorrow?");
mb.addMessage("question", "How to solve this problem?");
mb.addMessage("Sofia next week", "I am in Sofia next week.");
console.log("Msg count: " + mb.messageCount);
//Msg count: 4
console.log('Messages:\n' + mb);
//Messages:
//* [meeting] Let's meet at 17/11
//* [beer] Wanna drink beer tomorrow?
//* [question] How to solve this problem?
//* [Sofia next week] I am in Sofia next week.
console.log("Messages holding 'rakiya': " +
    JSON.stringify(mb.findBySubject('rakiya')));
//Messages holding 'rakiya': []
console.log("Messages holding 'ee': " +
    JSON.stringify(mb.findBySubject('ee')));
//Messages holding 'ee': [{"subject":"meeting","text":"Let's meet at 17/11"}
// ,{"subject":"beer","text":"Wanna drink beer tomorrow?"}
// ,{"subject":"Sofia next week","text":"I am in Sofia next week."}]
mb.deleteAllMessages();
console.log("Msg count: " + mb.messageCount);
//Msg count: 0
console.log('Messages:\n' + mb);
//Messages:
//* (empty mailbox)
console.log("New mailbox:\n" +
    new MailBox()
        .addMessage("Subj 1", "Msg 1")
        .addMessage("Subj 2", "Msg 2")
        .addMessage("Subj 3", "Msg 3")
        .toString());
//New mailbox:
//* [Subj 1] Msg 1
//* [Subj 2] Msg 2
//* [Subj 3] Msg 3