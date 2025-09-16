import { ValidatorFn } from "@angular/forms";

export interface DynamicnForm {
  /** Unique key for the FormControl */
  name: string;
  /** Label text for UI */
  label: string;
  /** Type of input: text, number, select, etc. */
  type: 'text' | 'number' | 'email' | 'select' | 'date' | 'group' | 'checkbox';
  /** Optional placeholder */
  placeholder?: string;
  /** Default value */
  defaultValue?: any;
  /** Angular validators */
  validators?: ValidatorFn[];
  /** Options if type = select */
  options?: { label: string; value: any }[];
  children?: DynamicnForm[];
}
