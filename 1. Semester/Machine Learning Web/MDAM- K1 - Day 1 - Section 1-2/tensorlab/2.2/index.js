// Load TensorFlow.js (pure JavaScript version)
const tf = require('@tensorflow/tfjs');

async function run() {
    // Wait for TensorFlow.js to initialize
    await tf.ready();

    console.log("TensorFlow.js version information:");
    console.log(tf.version);

    console.log(`TensorFlow.js backend: ${tf.getBackend()}`); // should print 'cpu'

    // Define a simple linear regression model
    const model = tf.sequential();
    model.add(tf.layers.dense({ units: 1, inputShape: [1] }));

    // Compile the model with optimizer and loss
    model.compile({ loss: 'meanSquaredError', optimizer: 'sgd' });

    // Generate synthetic training data
    const xs = tf.tensor2d([1, 2, 3, 4], [4, 1]);
    const ys = tf.tensor2d([1, 3, 5, 7], [4, 1]);
    // Train the model
    await model.fit(xs, ys, { epochs: 10 });

    // Make a prediction on new data
    const output = model.predict(tf.tensor2d([5], [1, 1]));
    output.print(); // Should print something close to [[9]]
}

// Run the async function
run();
