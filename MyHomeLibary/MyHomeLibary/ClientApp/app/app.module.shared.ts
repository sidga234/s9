import { NgModule } from '@angular/core';
import { LibraryService } from './Services/libraryservice.service';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchBookComponent } from './components/fetchbook/fetchbook.component';
import { createbook } from './components/addbooks/AddBooks.component';
import { searchbook } from './components/searchbook/searchbook.component';
import { searchresult } from './components/searchresult/searchresult.component'

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        FetchBookComponent,
        HomeComponent,
        createbook,
        searchbook,
        searchresult

    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'register-library', component: createbook },
            { path: 'library/edit/:id', component: createbook },
            { path: 'fetch-book', component: FetchBookComponent },
            { path: 'search-book', component: searchbook },
            { path: 'search-result', component: searchresult },
            { path: '**', redirectTo: 'home' }
        ])      
    ],
    providers: [LibraryService]
})
export class AppModuleShared {
}
