import { Component, Injector, AfterViewInit,OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
    templateUrl: './about.component.html',
    animations: [appModuleAnimation()]
})
export class AboutComponent extends AppComponentBase {

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    ngOnInit() {
         var chatHub = null;

        abp.signalr.autoConnect = true;
        abp.signalr.startConnection('/signalr-myChatHub', function (connection) {
            chatHub = connection; // Save a reference to the hub
        
            connection.on('getMessage', function (message) { // Register for incoming messages
                console.log('received message: ' + message);
            });
        }).then(function (connection) {
            abp.log.debug('Connected to myChatHub server!');

            abp.event.trigger('myChatHub.connected');
        });
        
        abp.event.on('myChatHub.connected', function() { // Register for connect event
            chatHub.invoke('sendMessage', "Hi everybody, I'm connected to the chat!"); // Send a message to the server
        });

        abp.event.on('abp.notifications.received', userNotification => {
            abp.notifications.showUiNotifyForUserNotification(userNotification);
        });

    }


}