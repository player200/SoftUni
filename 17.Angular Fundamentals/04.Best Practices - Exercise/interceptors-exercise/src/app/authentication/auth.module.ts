import { NgModule } from '@angular/core'
import { authComponents } from './index';
import { FormsModule } from '@angular/forms';
import { AuthService } from './auth.service';

@NgModule({
    declarations: [
        ...authComponents
    ],
    imports: [
        FormsModule
    ],
    providers: [
        AuthService
    ]
})
export class AuthModule { }