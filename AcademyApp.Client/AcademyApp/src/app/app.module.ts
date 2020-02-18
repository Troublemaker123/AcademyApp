import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { DashboardComponent } from './dashboard/dashboard.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { WarnDialogComponent } from './shared/warn-dialog/warn-dialog';
import { LoginModule } from './login/login.module';
import { MenuComponent } from './main.component';
import { Page404Component } from './page404/page404.component';
import { ErrorToolbarComponent } from './page404/error-toolbar.component';
import { MatMenuModule, MatSnackBarModule } from '@angular/material';
import { SnackBarComponent } from './shared/snack-bar/snack-bar.component';
import { NgxUiLoaderModule, NgxUiLoaderHttpModule, NgxUiLoaderRouterModule  } from  'ngx-ui-loader';
import { CoreModule } from './core.module';


@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    WarnDialogComponent,
    MenuComponent,
    Page404Component,
    ErrorToolbarComponent,   
   ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    CoreModule,
    FormsModule,
    ReactiveFormsModule,
    LoginModule,
    MatMenuModule,
    MatSnackBarModule,
    NgxUiLoaderModule,
    //NgxUiLoaderHttpModule.forRoot({ showForeground: true })
    NgxUiLoaderRouterModule.forRoot({ showForeground: true, exclude: ['/login', '/changepassword', '/reset']  })
  ],

  entryComponents: [
    WarnDialogComponent,
    SnackBarComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
