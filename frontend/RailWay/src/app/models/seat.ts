import { Guid } from "guid-typescript";

export interface Seat{
    id: string;
    carId: string;
    seatnumber: number;
    occupied: boolean;
    bookingCode?: string;
}