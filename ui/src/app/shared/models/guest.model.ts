export class Reservation {

    public guacID: string;
    public reservationNo: string;
    public guestName: string;
    public roomNo: string;
    public arrival: Date;
    public departure: Date;

    constructor(id: string, reservationNo: string, guestName: string, roomNo: string, arrival: Date, departure: Date)
    {   
        this.guacID = id;
        this.reservationNo = reservationNo;
        this.guestName = guestName;
        this.roomNo = roomNo;
        this.arrival = arrival;
        this.departure = departure;
    }
}

export class Guest {
    public guacID: string;
    public guestName: string;
}