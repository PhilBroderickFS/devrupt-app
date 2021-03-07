import { ApaleoNotificationType, ApaleoNotification } from './../../shared/models/apaleo.notification.model';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor() { }

  sendSuccessNotification = (title: string, message: string) => {
    let payload = this.generatePayload(title, message, ApaleoNotificationType.success);
    window.parent.postMessage(payload, "*");
  }

  sendErrorNotification = (title: string, message: string) => {
    let payload = this.generatePayload(title, message, ApaleoNotificationType.error);
    window.parent.postMessage(payload, "*");
  }

  sendAlertNotification = (title: string, message: string) => {
    let payload = this.generatePayload(title, message, ApaleoNotificationType.alert);
    window.parent.postMessage(payload, "*");
  }

  private generatePayload = (title: string, message: string, notificationType: ApaleoNotificationType) : string => {
    let notification = new ApaleoNotification(title, message, notificationType);
    return JSON.stringify(notification);
  }
}
