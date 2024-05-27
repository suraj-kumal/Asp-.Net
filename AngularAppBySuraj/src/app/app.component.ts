import { Component } from '@angular/core';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [
    RouterModule, // Ensure RouterModule is imported
    NavbarComponent,
    FooterComponent,
  ],
})
export class AppComponent {
  title = 'my-angular-app';
}
