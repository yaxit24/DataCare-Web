type CameraStream = Pick<MediaStream, 'getTracks'>;

/** A permission request may resolve after stop, unmount or another camera request. */
export class CameraRequestGuard {
  private generation = 0;
  private stream: CameraStream | null = null;

  begin() {
    this.stop();
    return this.generation;
  }

  isCurrent(generation: number) {
    return generation === this.generation;
  }

  isLive(generation: number) {
    return this.isCurrent(generation) && this.stream !== null;
  }

  token() {
    return this.generation;
  }

  accept(generation: number, stream: CameraStream) {
    if (!this.isCurrent(generation)) {
      for (const track of stream.getTracks()) track.stop();
      return false;
    }
    if (this.stream && this.stream !== stream)
      for (const track of this.stream.getTracks()) track.stop();
    this.stream = stream;
    return true;
  }

  stop() {
    this.generation += 1;
    const stream = this.stream;
    this.stream = null;
    if (stream) for (const track of stream.getTracks()) track.stop();
  }
}
