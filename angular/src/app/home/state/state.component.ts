import { Component, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { StateService } from '../services/state.service';
import { CountryService } from '../services/country.service';

@Component({
  selector: 'app-state',
  templateUrl: './state.component.html',
  styleUrl: './state.component.scss'
})
export class StateComponent {
  StateForm = new FormGroup({
    countryId: new FormControl('', Validators.required),
    name: new FormControl('', Validators.required),
  });

  State: string;
  visible: boolean = false;

  States: any = [];
  countries: any = [];
  dialogHeader: string = '';

  constructor(private StateService: StateService, private countryService: CountryService) {
    this.getAllStates();
  }

  ngOnInit() {}

  getAllStates() {
    this.StateService.getAll().subscribe(result => {
      debugger;
      this.States = result.items;
    });
  }

  getAllCountries() {
    this.countryService.getAll().subscribe(result => {
      debugger;
      this.countries = result.items;
    });
  }

  onStateDelete(id: string) {
    this.StateService.delete(id).subscribe(result => {
      debugger;
      this.getAllStates();
    });
  }

  onStateForm() {
    this.getAllCountries();
    this.dialogHeader = 'Add New State';
    this.visible = !this.visible;
  }

  OnStateSubmit() {
    debugger;
    if (this.StateForm.valid) {
      this.StateService.add(this.StateForm.value).subscribe(result => {
        debugger;
        this.getAllStates();
        this.visible = !this.visible;
        this.StateForm.reset();
      });
    } else {
      this.StateForm.touched;
    }
  }

  hideDialogEvent(hide: boolean) {}
}
