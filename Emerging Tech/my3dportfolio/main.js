import './style.css'
import * as  THREE from 'three';
import {OrbitControls} from 'three/examples/jsm/controls/OrbitControls.js'
import javascriptLogo from './javascript.svg'
import viteLogo from '/vite.svg'
import { setupCounter } from './counter.js'

const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera( 75, window.innerWidth/ window.innerHeight, 0.1, 1000);
const renderer = new THREE.WebGL1Renderer({
  canvas: document.querySelector('#bg'),
})

// set the sixe of the camera to be the size of the window
renderer.setPixelRatio(window.devicePixelRatio);
renderer.setSize(window.innerWidth, window.innerHeight);
camera.position.setZ(30);

// This causes the page to render anumatinons added to the page 
renderer.render(scene, camera);


// this is the ring in the center of the page 
const geometry = new THREE.TorusGeometry(10,3,16.100)
// MeshStandard material is ois the type of material that that ring will be 
// MesStandard Material can be replaced by MeshBasid material and this one will not need external lights 
const material = new THREE.MeshStandardMaterial({color: 0xFF6347});
const torus = new THREE.Mesh(geometry,material);

scene.add(torus)


// Lights on the page
// This is a point light this creates a light source for a point on the page
const pointLight = new THREE.PointLight(0xffffff)
pointLight.position.set(9, 9, 9)

// This lights up the whole scene and not just a section of the scene
const ambientlight = new THREE.AmbientLight(0xffffff)
scene.add(pointLight,ambientlight)


// These are helpers 
// The light helper is the little geimeric shape at the top left of the ring
// The Gridhelper is the grid on the page
const lightHelper = new THREE.PointLightHelper(pointLight)
const gridHelper = new THREE.GridHelper(200,50)
scene.add(lightHelper,gridHelper)

const controls = new OrbitControls(camera, renderer.domElement);


// Adds The Star to the Page
function addstar(){
  // Uses the THREE js Sphere Geometary to Add Tiny Sphears to the page
  const geometry = new THREE.SphereGeometry(0.25, 24, 24)
  // Gives the Sphers color
  const material = new THREE.MeshStandardMaterial({color:0xffffff})
  // Combines the sphere and the color
  const star = new THREE.Mesh(geometry,material);

  const [x, y, z] = Array(3).fill().map(() => THREE.MathUtils.randFloatSpread(100));

  star.position.set(x,y,z);

  // scene.add() adds the nes grometary to the scene
  scene.add(star)
}
Array(200).fill().forEach(addstar)


// Back Ground and Textures
// const spaceTexture = new THREE.TextureLoader().load('img/Night_Sky.png');
// scene.background = spaceTexture;


const nicholasTexture = new THREE.TextureLoader().load('img/mygrad.jpg');

const nicholas = new THREE.Mesh(
  new THREE.BoxGeometry(3,3,3),
  new THREE.MeshBasicMaterial({map: nicholasTexture})
);


const moonTexture = new THREE.TextureLoader().load('img/moon.jpg');

const mooon = new THREE.Mesh(
  new THREE.SphereGeometry(3,32,32),
  new THREE.MeshStandardMaterial({
    map: moonTexture
  })
);

// moonTexture.position.z = 20;
mooon.position.setX(15);
scene.add(mooon)


function moveCamera(){
  const t = document.body.getBoundingClientRect().top;
  mooon.rotation.x += 0.05;
  mooon.rotation.y += 0.075;
  mooon.rotation.z += 0.05;

  nicholas.rotation.y  += 0.01;
  nicholas.rotation.z  += 0.01;


  camera.position.z = t * -0.1;
  camera.position.x = t * -0.2;
  camera.position.y = t * -0.2;
}
document.body.onscroll = moveCamera

// Animate Additions to Pages
function animate(){
  requestAnimationFrame(animate);
  torus.rotation.x += 0.01;
  torus.rotation.y += 0.005;
  torus.rotation.z += 0.01;
  controls.update()


  renderer.render(scene, camera);
}
animate()
// setupCounter(document.querySelector('#counter'))

