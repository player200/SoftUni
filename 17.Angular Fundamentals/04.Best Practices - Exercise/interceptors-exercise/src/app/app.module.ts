import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app.routing';
import { CustomFormsModule } from 'ng2-validation'
import { AuthModule } from './authentication/auth.module';
import { FurnitureModule } from './furniture/furniture.module';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { HomeComponent } from './home/home.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { CreateFurnitureComponent } from './furniture/create-furniture/create-furniture.component';
import { AllFurnitureComponent } from './furniture/all-furniture/all-furniture.component';
import { FurnituresDetailsComponent } from './furniture/furnitures-details/furnitures-details.component';
import { MyFurnitureComponent } from './furniture/my-furniture/my-furniture.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    CustomFormsModule,
    BrowserAnimationsModule,
    AuthModule,
    FurnitureModule,
    ToastrModule.forRoot()
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
