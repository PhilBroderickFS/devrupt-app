export class Reservation {

    public reservationNo: string;
    public guestName: string;
    public roomNo: string;
    public arrival: Date;
    public departure: Date;

    constructor(reservationNo: string, guestName: string, roomNo: string, arrival: Date, departure: Date)
    {
        this.reservationNo = reservationNo;
        this.guestName = guestName;
        this.roomNo = roomNo;
        this.arrival = arrival;
        this.departure = departure;
    }
}