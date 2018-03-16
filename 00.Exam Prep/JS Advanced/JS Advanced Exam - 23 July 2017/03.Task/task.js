class Task {
    constructor(title, deadline) {
        this.title = title
        this.deadline = deadline
        this.status = 'Open'
    }

    get isOverdue() {
        return this.deadline < Date.now()
            && this.status !== 'Complete'
    }

    get deadline() {
        return this._deadline
    }

    set deadline(value) {
        if (value < Date.now()) {
            throw new Error()
        }

        this._deadline = value
    }

    get criteria() {
        if (this.isOverdue) {
            return 1
        }
        else if (this.status === 'In Progress') {
            return 2
        }
        else if (this.status === 'Open') {
            return 3
        }
        else {
            return 4
        }
    }

    toString() {
        let statusIcon = ''
        if (this.isOverdue) {
            statusIcon = '\u26A0'
            return `[${statusIcon}] ${this.title}(overdue)`
        }
        else if (this.status === 'Open') {
            statusIcon = '\u2731'
            return `[${statusIcon}] ${this.title} (deadline: ${this.deadline})`
        }
        else if (this.status === 'Complete') {
            statusIcon = '\u2714'
            return `[${statusIcon}] ${this.title} (deadline: ${this.deadline})`
        }
        else if (this.status === 'In Progress') {
            statusIcon = '\u219D'
            return `[${statusIcon}] ${this.title} (deadline: ${this.deadline})`
        }
    }

    static comparator(a, b) {
        let compare = a.criteria - b.criteria

        if(compare !== 0){
            return compare
        }
        else {
            return a.deadline - b.deadline
        }
    }
}

let date1 = new Date();
date1.setDate(date1.getDate() + 7); // Set date 7 days from now
let task1 = new Task('JS Homework', date1);
let date2 = new Date();
date2.setFullYear(date2.getFullYear() + 1); // Set date 1 year from now
let task2 = new Task('Start career', date2);
console.log(task1 + '\n' + task2);
let date3 = new Date();
date3.setDate(date3.getDate() + 3); // Set date 3 days from now
let task3 = new Task('football', date3);
// Create two tasks with deadline set to current time
let task4 = new Task('Task 4', new Date());
let task5 = new Task('Task 5', new Date());
task1.status = 'In Progress';
task3.status = 'In Progress';
task5.status = "Complete";
let tasks = [task1, task2, task3, task4, task5];
setTimeout(() => {
    tasks.sort(Task.comparator);
    console.log(tasks.join('\n'));
}, 1000); // Sort and print one second later
// should throw an Error
//let overdueTask = new Task('Overdue Task', new Date(2005, '4', '20'));
// should throw an Error
//task1.deadline = new Date(2005, '4', '20');