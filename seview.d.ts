type element = object;

type transformFn = (node: any) => element;

type sv = (transform: transformFn, options: object) => h;

type Child = string;
interface ChildArray extends Array<Children> {}
type Children = Child | ChildArray;

type h = (children: Children) => any;
