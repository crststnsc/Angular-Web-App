import { Component } from '@angular/core';
import { AnnouncementService } from '../services/announcement.service';
import { Announcement } from './../announcement';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  title = 'notifications-app';
  filteredAnnouncements: Announcement[] = [];
  
  constructor(private announcementService: AnnouncementService) {}
  
  ngOnInit(): void {
    this.announcementService.serviceCall();
    this.announcementService
    .getAnnouncements()
    .subscribe((announcements) => (this.filteredAnnouncements = announcements));
  }
  
  filterAnnouncements(selectedCategory: string) {
    if (!selectedCategory) {
      this.announcementService
        .getAnnouncements()
        .subscribe(
          (announcements) => (this.filteredAnnouncements = announcements)
        );
      return;
    }
    this.announcementService
      .getAnnouncements()
      .subscribe(
        (announcements) =>
          (this.filteredAnnouncements = announcements.filter(
            (announcement) => announcement.categoryId === selectedCategory
          ))
      );
  }

}
