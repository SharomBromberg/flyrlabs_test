import { TransportInterface } from "./transport-interface";

export interface FlightInterface {
    id: number;
    origin: string;
    destination: string;
    departureTime: Date;
    arrivalTime: Date;
    price: number;
    transport: TransportInterface;
}
