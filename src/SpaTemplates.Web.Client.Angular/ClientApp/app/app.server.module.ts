import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { XHRBackend } from '@angular/http';

import { AuthGuard } from './auth-guard';
import { UserService } from './../shared/services/user-service';
import { AuthenticateXhrBackend } from './authenticate-xhr-backend';

@NgModule({
    bootstrap: [AppComponent],
    imports: [
        ServerModule,
        AppModuleShared
    ],
    providers: [
        AuthGuard,
        UserService, {
            provide: XHRBackend,
            useClass: AuthenticateXhrBackend
        }
    ]
})

export class AppModule {
}
