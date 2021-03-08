export class ApaleoNotification {
    private static DEFAULT_TYPE = "notification";
    
    public type: string;
    public title: string;
    public content: string;
    public notificationType: string;

    constructor(title: string, content: string, notificationType: ApaleoNotificationType) {
        this.type = ApaleoNotification.DEFAULT_TYPE;
        this.title = title;
        this.content = content;
        this.notificationType = notificationType.toString();
    }

}

export enum ApaleoNotificationType {
    success = "success",
    alert = "alert",
    error = "error"
}