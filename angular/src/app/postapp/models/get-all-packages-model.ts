import {StatusEnum} from "../enums/status-enum";

export interface GetAllPackagesModel {
  status: StatusEnum;
  sender: string;
  receiver: string;
  postMachineId: number;
}
