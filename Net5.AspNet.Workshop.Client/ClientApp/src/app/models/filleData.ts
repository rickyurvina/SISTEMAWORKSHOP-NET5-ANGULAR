import { SafeResourceUrl } from "@angular/platform-browser";

export class FileData {
  constructor() {
    this.FileDataId = 0;
    this.FileName = "";
    this.Extension = "";
    this.Type = "";
    this.Size = 0;
    this.Path = "";
    this.Base64 = "";    
  }
  public FileDataId: number;
  public FileName: string;
  public Extension: string;
  public Type: string;
  public Size: number;
  public Path: string;
  public Base64: string;
  public SafeResourceUrl?: SafeResourceUrl;
}
