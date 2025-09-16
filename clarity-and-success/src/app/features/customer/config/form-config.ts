import { Validators } from '@angular/forms';
import { DynamicnForm } from '../models/dynamic-form.model';

export const FURTHER_DATA1_FORM: DynamicnForm[] = [
  { name: 'category1', label: 'Category 1', type: 'text', validators: [Validators.required] },
  { name: 'category2', label: 'Category 2', type: 'text', validators: [Validators.required] },
  { name: 'category3', label: 'Category 3', type: 'text', validators: [Validators.required] },
  { name: 'category4', label: 'Category 4', type: 'text' },
  { name: 'category5', label: 'Category 5', type: 'text' },
  { name: 'category6', label: 'Category 6', type: 'text' },
  { name: 'category7', label: 'Category 7', type: 'text' },
  { name: 'category8', label: 'Category 8', type: 'text' },
  { name: 'category9', label: 'Category 9', type: 'text' },
  { name: 'category10', label: 'Category 10', type: 'text' },

  { name: 'profession', label: 'Profession', type: 'text', validators: [Validators.required] },
  { name: 'hobby', label: 'Hobby', type: 'text' },
  { name: 'customerCardType', label: 'Customer Card Type', type: 'text' },
  {
    name: 'customerCardNo',
    label: 'Customer Card No',
    type: 'text',
    validators: [Validators.pattern('^[0-9]*$')],
  },
  { name: 'referredBy', label: 'Referred By', type: 'text' },

  // Nested group for advertising
  {
    name: 'advertising',
    label: 'Advertising Preferences',
    type: 'group',
    children: [
      { name: 'none', label: 'None', type: 'checkbox', defaultValue: false },
      { name: 'mail', label: 'Mail', type: 'checkbox', defaultValue: false },
      { name: 'email', label: 'Email', type: 'checkbox', defaultValue: true },
      { name: 'sms', label: 'SMS', type: 'checkbox', defaultValue: false },
      { name: 'call', label: 'Call', type: 'checkbox', defaultValue: false },
      {
        name: 'dataProtectionDecl',
        label: 'Data Protection Declaration',
        type: 'checkbox',
        defaultValue: true,
      },
    ],
  },
];
