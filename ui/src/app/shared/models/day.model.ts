export class Day {
    longDay: string;
    dayMonth: string;
    date: Date;

    constructor(date: Date) {
        this.longDay = new Intl.DateTimeFormat('en-GB', { weekday: 'long'}).format(date);

        this.dayMonth = new Intl.DateTimeFormat('en-GB', { day: 'numeric', month: 'short' }).format(date);

        this.date = date;
    }
}