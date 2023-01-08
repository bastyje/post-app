export interface UpdatePostMachineCommand {
  id: number;
  name: string;
  country: string;
  city: string;
  postalCode: string;
  street: string;
  number: string;
  preciseLocation: string;
}
