import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FileUploaderService } from './file-uploader.service';

@Component({
  selector: 'file-uploader-form',
  templateUrl: './file-uploader-form.component.html',
  styleUrls: ['./file-uploader-form.component.scss']
})
export class FileUploaderFormComponent implements OnInit {

  ngOnInit(): void {
    this.formData = new FormData();
  }

  file: any;
  private formData: FormData;
  fileNameList: Array<string> = [];
  fileList: Array<any> = [];

  constructor(    
    private fileUploaderService: FileUploaderService) { }

  get hasFiles(): boolean{
    return (this.fileList && this.fileList.length > 0);
  }
  onSendFileButtonClick() {
    this.sendFiles();
  }

  afterFileSelect(event: any) {
    if (event.target.files.length) {
      var regex = new RegExp(/^([\w:\\]+)(.ofx)$/,'i');
      if (regex.test(event.srcElement.value)) {
        this.fileList.push(event.target.files[0]);
        //this.fileNameList.push(event.target.files[0].name);
        //this.formData.append('file',event.target.files[0])
      }else {
        console.error("Invalid File.");
      }
    }
  }

  sendFiles() {
    this.fileList.forEach(x => {
      this.formData.append('file',x)
    });    
    this.fileUploaderService.sendFile(this.formData).subscribe(response => {
      console.log(response);
    });
  }

}
