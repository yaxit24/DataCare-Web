/** Every mounted scope transition needs its own acknowledgment, including a return to an older scope. */
export class ImageScopeBarrier {
  private scope: string;
  private generation = 0;
  private acknowledged = 0;

  constructor(initialScope: string) {
    this.scope = initialScope;
  }

  observe(scope: string) {
    if (scope !== this.scope) {
      this.scope = scope;
      this.generation += 1;
    }
    return this.acknowledged !== this.generation;
  }

  generationToken() {
    return this.generation;
  }

  acknowledge(scope: string, generation: number) {
    if (scope !== this.scope || generation !== this.generation) return false;
    this.acknowledged = this.generation;
    return true;
  }
}
