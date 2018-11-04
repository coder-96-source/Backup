export class SideMenuNode {
  sideNodes: SideMenuNode[];
  id: number;
  title: string;
  type: any;
}

/** Flat node with expandable and level information */
export class SideMenuFlatNode {
  constructor(
    public expandable: boolean, public title: string, public level: number, public id: any) { }
}
