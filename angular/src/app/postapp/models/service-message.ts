import { ErrorMessage } from "./error-message";

export interface ServiceMessageWithContent<T> extends ServiceMessage {
  content: T;
}

export interface ServiceMessage {
  errorMessages: ErrorMessage[];
  success: boolean;
}
