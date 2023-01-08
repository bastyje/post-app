import {
  AfterViewInit,
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
  ViewChild
} from '@angular/core';
import { PaginationResponse } from "../../../../models/pagination-response";
import { PaginationRequest } from "../../../../models/pagination-request";

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent implements OnInit, AfterViewInit, OnChanges {

  constructor() {}

  @ViewChild('inputElement') inputElement: ElementRef<HTMLInputElement> = {} as ElementRef<HTMLInputElement>;

  @Input() pagedResponse: PaginationResponse<any> = <PaginationResponse<any>> {
    content: [],
    totalItems: 0,
    lastPage: 0,
    currentPage: 1,
    pageSize: 10
  };

  @Output() paginationChanged: EventEmitter<PaginationRequest> = new EventEmitter<PaginationRequest>();

  ngOnInit(): void {}

  ngOnChanges(changes: SimpleChanges) {
    if (changes['pagedResponse'].currentValue !== undefined && this.inputElement.nativeElement !== undefined) {
      this.changePage(changes['pagedResponse'].currentValue.currentPage)
    }
  }

  ngAfterViewInit(): void {
    this.changePage(this.pagedResponse.currentPage);
  }

  goToFirst(): void {
    if (!this.isPreviousDisabled()) {
      this.changePage(1);
      this.paginationChanged.emit(this.pagedResponse);
    }
  }

  goToPrevious(): void {
    if (!this.isPreviousDisabled()) {
      this.changePage(this.pagedResponse.currentPage - 1);
      this.paginationChanged.emit(this.pagedResponse);
    }
  }

  goToNext(): void {
    if (!this.isNextDisabled()) {
      this.changePage(this.pagedResponse.currentPage += 1);
      this.paginationChanged.emit(this.pagedResponse);
    }
  }

  goToLast(): void {
    if (!this.isNextDisabled()) {
      this.changePage(this.pagedResponse.lastPage);
      this.paginationChanged.emit(this.pagedResponse);
    }
  }

  isPreviousDisabled(): boolean {
    return this.pagedResponse.currentPage <= 1;
  }

  isNextDisabled(): boolean {
    return this.pagedResponse.currentPage === this.pagedResponse.lastPage;
  }

  getFirstItemIndex(): number {
    return this.getLastItemIndex() === 0 ? 0 : (this.pagedResponse.currentPage - 1) * this.pagedResponse.pageSize + 1;
  }

  getLastItemIndex(): number {
    return this.pagedResponse.totalItems < this.pagedResponse.currentPage * this.pagedResponse.pageSize ? this.pagedResponse.totalItems : this.pagedResponse.currentPage * this.pagedResponse.pageSize;
  }

  onPageSizeChange(): void {
    this.paginationChanged.emit(this.pagedResponse);
  }

  onInput(): void {
    const value = parseInt(this.inputElement.nativeElement.value);
    if (!isNaN(value)) {
      if (value <= 0) {
        this.changePage(1);
      } else if (value > this.pagedResponse.lastPage) {
        this.changePage(this.pagedResponse.lastPage)
      } else {
        this.changePage(value)
      }
    }
  }

  changePage(page: number): void {
    this.pagedResponse.currentPage = page;
    this.inputElement.nativeElement.value = `${page}`;
  }
}
