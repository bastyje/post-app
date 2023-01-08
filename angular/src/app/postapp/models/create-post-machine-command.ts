export interface CreatePostMachineCommand {
  name: string;
  country: string;
  city: string;
  postalCode: string;
  street: string;
  number: string;
  preciseLocation: string;
}
