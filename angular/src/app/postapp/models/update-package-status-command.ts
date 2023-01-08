import {StatusEnum} from "../enums/status-enum";

export interface UpdatePackageStatusCommand {
  id: number;
  status: StatusEnum;
}
