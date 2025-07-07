import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [HeaderComponent,CommonModule,FormsModule,RouterOutlet,],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  name = 'GEC';

  visibility = true;

  list = ["item 1", "item 2", "item 3","item 4","item 5"];

  test = 'default';

  listner() {
    this.visibility = !this.visibility;
    console.log('Button clicked! Visibility:', this.visibility);
    console.log(this.test)
  }
}
