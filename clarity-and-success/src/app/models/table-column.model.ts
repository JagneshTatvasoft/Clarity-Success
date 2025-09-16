export interface TableColumn<T> {
  key: string; // property name in data object
  label: string; // column header
  visible: boolean;
  accessor: (row: T) => any;
}
  